using System;
using Constructs;
using HashiCorp.Cdktf;

namespace MyCompany.MyApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            App app = new App();
            MainStack stack = new MainStack(app, "aws_instance");
            new CloudBackend(
                stack,
                new CloudBackendConfig
                {
                    Hostname = "app.terraform.io",
                    Organization = "ST-GitHub",
                    Workspaces = new NamedCloudWorkspace("cdktf-lab")
                }
            );

            app.Synth();
        }
    }
}
