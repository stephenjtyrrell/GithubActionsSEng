using System;
using Constructs;
using HashiCorp.Cdktf;
using HashiCorp.Cdktf.Providers.Aws.Provider;
using HashiCorp.Cdktf.Providers.Aws.Instance;

namespace MyCompany.MyApp
{
    class MainStack : TerraformStack
    {
        public MainStack(Construct scope, string id) : base(scope, id)
        {
            new AwsProvider(this, "AWS", new AwsProviderConfig { Region = "us-west-1" });

            Instance instance = new Instance(this, "compute", new InstanceConfig
            { 
                Ami = "ami-01456a894f71116f2",
                InstanceType = "t2.micro",
            });

            new TerraformOutput(this, "public_ip", new TerraformOutputConfig
            {
                Value = instance.PublicIp
            });
        }
    }
}
