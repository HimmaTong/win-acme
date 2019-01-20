﻿using Newtonsoft.Json;
using PKISharp.WACS.Extensions;
using PKISharp.WACS.Plugins.Base.Options;

namespace PKISharp.WACS.Plugins.ValidationPlugins.Dns
{
    class AzureOptions : ValidationPluginOptions<Azure>
    {
        public override string Name => "Azure";
        public override string Description => "Change records in Azure DNS";
        public override string ChallengeType { get => Constants.Dns01ChallengeType; }

        public string ClientId { get; set; }
        public string ResourceGroupName { get; set; }
        public string SecretSafe { get; set; }

        [JsonIgnore]
        public string Secret
        {
            get => SecretSafe.Unprotect();
            set => SecretSafe = value.Protect();
        }

        public string SubscriptionId { get; set; }
        public string TenantId { get; set; }
    }
}
