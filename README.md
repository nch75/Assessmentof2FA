# Two Factor Authentication Service

A simple 2FA service implemented in ASP.NET Core to generate and validate authentication codes.

##  Features

- Generate a 6-digit authentication code for a given phone number.
- Validate a given authentication code for a phone number.
- Configurable code lifetime and maximum concurrent codes per phone.
- In-memory caching for storing the authentication codes.
- Easily extendible for integration with real SMS gateways in the future.

##  Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

## How to Run

1. **Clone the repository**:
   ```bash
   git clone [https://github.com/nch75/Assessmentof2FA.git]
# Assessmentof2FA
1. Navigate to Project directory.
2. Run the application.
3. Acess the API documentation at "https://localhost:7034/swagger".
4. API Endpoints:
##  Generate Code
```  
  Endpoint: POST /api/_2fServices/generate
  For Request Payload:{
    "Phone": "1234567890"
}
  Response:
Success: { "Success": true }
Error (Too many codes): { "Message": "Too many concurrent codes" }
  Validate Code
Endpoint: POST /api/_2fServices/validate
Request Payload:
{
    "Phone": "1234567890",
    "Code": "123456"
}
{
    "Phone": "1234567890",
    "Code": "123456"
}
```
# Configuration
   We can adjust the service configurations in the appsettings.json file:
-  __CodeLifetime: Lifetime of the generated code in seconds.__
*  __MaxConcurrentCodes: Maximum number of concurrent codes allowed per phone.__

### Future Enhancements
*   __SMS Gateway Integration: Integrate with actual SMS gateways to send authentication codes.__
-  __Rate-limiting: Implement request rate-limiting to prevent abuse.__
+  __Enhanced Security: Implement additional security checks and validation mechanisms.__


