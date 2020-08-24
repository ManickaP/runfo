﻿using DevOps.Util.DotNet;
using DevOps.Util.Triage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Status.Util
{
    public class StatusBuildSearchOptions
    {
        public const int DefaultCount = 10;
        public const ModelBuildKind DefaultKind = ModelBuildKind.All;

        public string? Definition { get; set; }
        public int Count { get; set; } = DefaultCount;
        public ModelBuildKind Kind { get; set; } = DefaultKind;
        public string? Repository { get; set; }

        public int? DefinitionId
        {
            get
            {
                if (!string.IsNullOrEmpty(Definition))
                {
                    if (DotNetUtil.TryGetDefinitionId(Definition, out var _, out var id))
                    {
                        return id;
                    }

                    if (int.TryParse(Definition, out id))
                    {
                        return id;
                    }
                }

                return null;
            }
        }

        public IQueryable<ModelBuild> GetModelBuildsQuery(TriageContext triageContext) =>
            GetModelBuildsQuery(new TriageContextUtil(triageContext));

        public IQueryable<ModelBuild> GetModelBuildsQuery(
            TriageContextUtil triageContextUtil,
            Func<IQueryable<ModelBuild>, IQueryable<ModelBuild>>? beforeCountFunc = null)
        {
            var definitionId = DefinitionId;
            string? definitionName = definitionId is null
                ? Definition
                : null;
            var query = triageContextUtil.GetModelBuildsQuery(
                definitionId: definitionId,
                definitionName: definitionName,
                count: null,
                kind: Kind);

            if (beforeCountFunc is object)
            {
                query = beforeCountFunc(query);
            }

            return query.Take(Count);
        }

        public string GetUserQueryString()
        {
            var builder = new StringBuilder();
            if (!string.IsNullOrEmpty(Definition))
            {
                Append($"definition:{Definition} ");
            }

            if (!string.IsNullOrEmpty(Repository))
            {
                Append($"repository:{Repository}");
            }

            if (Kind != DefaultKind)
            {
                var kind = Kind switch
                {
                    ModelBuildKind.All => "all",
                    ModelBuildKind.MergedPullRequest => "mpr",
                    ModelBuildKind.PullRequest => "pr",
                    ModelBuildKind.Rolling => "rolling",
                    _ => throw new InvalidOperationException($"Invalid kind {Kind}"),
                };
                Append($"kind:{kind}");
            }

            if (Count != DefaultCount)
            {
                Append($"count:{Count}");
            }

            return builder.ToString();

            void Append(string message)
            {
                if (builder.Length != 0)
                {
                    builder.Append(" ");
                }

                builder.Append(message);
            }
        }

        public void Parse(string userQuery)
        {
            foreach (var tuple in DotNetQueryUtil.TokenizeQueryPairs(userQuery))
            {
                switch (tuple.Name.ToLower())
                {
                    case "definition":
                        Definition = tuple.Value;
                        break;
                    case "repository":
                        Repository = tuple.Value;
                        break;
                    case "count":
                        Count = int.Parse(tuple.Value);
                        break;
                    case "kind":
                        Kind = tuple.Value.ToLower() switch
                        {
                            "all" => ModelBuildKind.All,
                            "rolling" => ModelBuildKind.Rolling,
                            "pullrequest" => ModelBuildKind.PullRequest,
                            "pr" => ModelBuildKind.PullRequest,
                            "mergedpullrequest" => ModelBuildKind.MergedPullRequest,
                            "mpr" => ModelBuildKind.MergedPullRequest,
                            _ => throw new Exception($"Invalid build kind {tuple.Value}")
                        };
                        break;
                    default:
                        throw new Exception($"Invalid option {tuple.Name}");
                }
            }
        }
    }
}
