namespace Modules.Backend.Services
{
    public class ServiceNumberOne : IServiceNumberOne
    {        
        public string MethodOne(string input1, string input2)
        {
            return input1 + input2;
        }
    }
}
