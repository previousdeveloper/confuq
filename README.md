# confuq

Github based Configuration library

## How to use  

**Configuration**  

```csharp
  public class ConfuqConfiguration : IConfiguration
    {
        public string GetBranch()
        {
            return "master";
        }

        public string GetApplicationName()
        {
            return "firstApp";
        }

        public string GetBaseUrl()
        {
            return "https://raw.githubusercontent.com/previousdeveloper/cfg4j-git-sample-config";
        }

        public double? Interval => 1 * 1000;
    }
    
     private IConfiguration _configuration = new ConfuqConfiguration();
     private IConfuqClient _confuqClient = new ConfuqClient(_configuration);

```

```csharp
  
  GET KEY
  
  bool result = _confuqClient.Get<bool>("isValid");

  

```


