using MessageSenderService;
using System;
using System.Configuration;
using Topshelf;

public class Program
{
    public static void Main()
    {
        var queueConnectionString = ConfigurationManager.AppSettings["QueueConnectionString"];
        var serviceName = ConfigurationManager.AppSettings["ServiceName"];
       var rc = HostFactory.Run(x =>                                   
        {
            x.Service<HeartbeatService>(s =>                                   
            {
                s.ConstructUsing(name => new HeartbeatService(queueConnectionString));                
                s.WhenStarted(tc => tc.Start());                         
                s.WhenStopped(tc => tc.Stop());                          
            });
            x.RunAsLocalSystem();                                       

            x.SetDescription("Sends a hearbeat to a message queue");                   
            x.SetDisplayName(serviceName);                                  
            x.SetServiceName(serviceName);                                  
        });                                                             

        var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());  
        Environment.ExitCode = exitCode;
    }
}