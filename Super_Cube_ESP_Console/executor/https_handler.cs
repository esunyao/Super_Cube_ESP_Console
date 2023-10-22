using Microsoft.Maui.Controls;
using System.Reflection;

namespace Super_Cube_ESP_Console.executor;

[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
sealed class HandleAttribute : Attribute
{
    public string Module { get; }

    public HandleAttribute(string module)
    {
        Module = module;
    }
}

public class https_handler
{
    private static Dictionary<string, List<Func<https_handler, Dictionary<string, object>, Task>>> handlers = new Dictionary<string, List<Func<https_handler, Dictionary<string, object>, Task>>>();

    public async Task ActivationHandler(string module, Dictionary<string, object> kwargs)
    {
        try
        {
            if (handlers.ContainsKey(module))
            {
                foreach (var handler in handlers[module])
                {
                    await handler(this, kwargs);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void RegisterHandlers(object obj)
    {
        var methods = obj.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance);

        foreach (var method in methods)
        {
            var attributes = method.GetCustomAttributes(typeof(HandleAttribute), inherit: true);

            foreach (HandleAttribute attribute in attributes)
            {
                if (!handlers.ContainsKey(attribute.Module))
                {
                    handlers[attribute.Module] = new List<Func<https_handler, Dictionary<string, object>, Task>>();
                }

                Func<https_handler, Dictionary<string, object>, Task> handler = async (self, kwargs) =>
                {
                    await Task.Yield();
                    await (Task)method.Invoke(obj, new object[] { self, kwargs });
                };

                handlers[attribute.Module].Add(handler);
            }
        }
    }
}