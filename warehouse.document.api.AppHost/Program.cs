var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.warehouse_management_application>("warehouse-management-application");

builder.Build().Run();
