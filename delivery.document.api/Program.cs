using delivery.document.api.Brokers.DateTimes;
using delivery.document.api.Brokers.Loggings;
using delivery.document.api.Brokers.Storages;
using delivery.document.api.Brokers.UniqueIDGenerators;
using delivery.document.api.Options;
using delivery.document.api.Services.Foundations.Addresses;
using delivery.document.api.Services.Foundations.Customers;
using delivery.document.api.Services.Foundations.DeliveryDocuments;
using delivery.document.api.Services.Foundations.Invoices;
using delivery.document.api.Services.Foundations.OrderItems;
using delivery.document.api.Services.Foundations.Orders;
using delivery.document.api.Services.Foundations.Payments;
using delivery.document.api.Services.Foundations.Products;
using delivery.document.api.Services.Foundations.Shipments;

var builder = WebApplication.CreateBuilder(args);

#region Brokers
builder.Services.AddSingleton<IStorageBroker, StorageBroker>();
builder.Services.AddTransient<ILoggingBroker, LoggingBroker>();
builder.Services.AddTransient<IDateTimeBroker, DateTimeBroker>();
builder.Services.AddTransient<IUniqueIDGeneratorBroker, UniqueIDGeneratorBroker>();
#endregion

#region Services
builder.Services.AddTransient<IAddressService, AddressService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IDeliveryDocumentService, DeliveryDocumentService>();
builder.Services.AddTransient<IInvoiceService, InvoiceService>();
builder.Services.AddTransient<IOrderItemService, OrderItemService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IPaymentService, PaymentService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IShipmentService, ShipmentService>();
#endregion


#region Mongo options
var mongoDbOptions = new MongoDbOptions();
builder.Configuration.Bind(nameof(MongoDbOptions), mongoDbOptions);
var mongoDbOptionsSection = builder.Configuration.GetSection(nameof(MongoDbOptions));
builder.Services.Configure<MongoDbOptions>(mongoDbOptionsSection);
builder.Services.AddScoped<MongoDbOptions>();
#endregion



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
