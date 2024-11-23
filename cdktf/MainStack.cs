using System;
using Constructs;
using HashiCorp.Cdktf;
using HashiCorp.Cdktf.Providers.Aws.Provider;
using HashiCorp.Cdktf.Providers.Github.Provider;
using HashiCorp.Cdktf.Providers.Aws.Instance;
using HashiCorp.Cdktf.Providers.Github.DataGithubRepository;
using HashiCorp.Cdktf.Providers.Github.ActionsVariable;
using HashiCorp.Cdktf.Providers.Aws.Vpc;
using HashiCorp.Cdktf.Providers.Aws.Subnet;


namespace MyCompany.MyApp
{
    class MainStack : TerraformStack
    {
        public MainStack(Construct scope, string id) : base(scope, id)
        {
            new AwsProvider(this, "AWS", new AwsProviderConfig { Region = "us-west-1" });
            
            Vpc vpc = new Vpc(this, "vpc", new VpcConfig
            {
                CidrBlock = "10.0.0.0/16"
            });

            Subnet PublicSubnet = new Subnet(this, "public_subnet", new SubnetConfig
            {
                VpcId = vpc.Id,
                CidrBlock = "10.0.0.0/24",
                MapPublicIpOnLaunch = true
            });

            Instance instance = new Instance(this, "compute", new InstanceConfig
            { 
                SubnetId = PublicSubnet.Id,
                Ami = "ami-01456a894f71116f2",
                InstanceType = "t2.micro",
                AssociatePublicIpAddress = true
            });

            new TerraformOutput(this, "public_ip", new TerraformOutputConfig
            {
                Value = instance.PublicIp
            });

        }
    }
}
