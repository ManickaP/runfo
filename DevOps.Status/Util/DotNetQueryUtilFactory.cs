﻿using AspNet.Security.OAuth.VisualStudio;
using DevOps.Util;
using DevOps.Util.DotNet;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevOps.Status.Util
{
    public sealed class DotNetQueryUtilFactory
    {
        public IConfiguration Configuration { get; }
        public IHttpContextAccessor HttpContextAccessor { get; }

        public DotNetQueryUtilFactory(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            Configuration = configuration;
            HttpContextAccessor = httpContextAccessor;
        }

        public async Task<DevOpsServer> CreateDevOpsServerForUserAsync()
        {
            var accessToken = await HttpContextAccessor.HttpContext.GetTokenAsync(VisualStudioAuthenticationDefaults.AuthenticationScheme, "access_token");
            var token = new AuthorizationToken(AuthorizationKind.BearerToken, accessToken);
            return new DevOpsServer(DotNetConstants.AzureOrganization, token);
        }

        public DevOpsServer CreateDevOpsServerForApp()
        {
            var azdoToken = Configuration[DotNetConstants.ConfigurationAzdoToken];
            var token = new AuthorizationToken(AuthorizationKind.PersonalAccessToken, azdoToken);
            return new DevOpsServer(DotNetConstants.AzureOrganization, token);
        }

        public DevOpsServer CreateDevOpsServerForAnonymous() => new DevOpsServer(DotNetConstants.AzureOrganization);

        public HelixServer CreateHelixServerForAnonymous() => new HelixServer();

        public async Task<DotNetQueryUtil> CreateDotNetQueryUtilForUserAsync() => CreateForServer(await CreateDevOpsServerForUserAsync());

        public DotNetQueryUtil CreateDotNetQueryUtilForApp() => CreateForServer(CreateDevOpsServerForApp());

        public DotNetQueryUtil CreateDotNetQueryUtilForAnonymous() => CreateForServer(CreateDevOpsServerForAnonymous());

        private DotNetQueryUtil CreateForServer(DevOpsServer server)
        {
            // https://github.com/jaredpar/devops-util/issues/19
            // Consider using a cache here
            var azureUtil = new AzureUtil(server);
            return new DotNetQueryUtil(server, azureUtil);
        }
    }
}
