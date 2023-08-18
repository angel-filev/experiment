using System.Reflection;
using System.Text;

namespace NullObject;

public interface INullObject<out T>
{
    public static abstract T Null { get; }

    public bool IsNull
    {
        get
        {
            var propertyInfo = typeof(T).GetProperty("Null");
            if (propertyInfo == null || propertyInfo.GetMethod == null)
            {
                throw new Exception("The type T must have a static property named 'Null'");
            }
            var nullObject = (T)propertyInfo.GetMethod.Invoke(null, null)!;
            //use reflection to compare all public instance properties
            var properties = typeof(T).GetProperties(BindingFlags.Public|BindingFlags.Instance);
            foreach (var property  in properties)
            {
                var thisValue = property.GetValue(this);
                var nullValue = property.GetValue(nullObject);
                if (thisValue != nullValue) return false;
            }
            
            //use reflection to compare all public instance fields
            var fields = typeof(T).GetFields(BindingFlags.Public|BindingFlags.Instance);
            foreach (var field  in fields)
            {
                var thisValue = field.GetValue(this);
                var nullValue = field.GetValue(nullObject);
                if (thisValue != nullValue) return false;
            }
            
            return true;
        }
    }
}