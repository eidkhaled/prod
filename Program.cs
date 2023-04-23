using Confluent.Kafka;
using Newtonsoft.Json;

var config = new ProducerConfig
{
    BootstrapServers = "9092"
};
using var Producer=new ProducerBuilder<Null,String>(config).Build();
try
{
    string? State; 
    while ((State=Console.ReadLine())!=null)
    {
        var response = await Producer.ProduceAsync("eid Topic",
        new Message<Null, string> { Value =JsonConvert.SerializeObject(new Weather( 
        State,70))});

    }
    
         

}
catch(ProduceException<Null,string> exc)
{
    Console.WriteLine(exc.Message);
}
public record Weather(string State,int temp);