var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Courier_Management_System>("courier-management-system");

builder.Build().Run();
