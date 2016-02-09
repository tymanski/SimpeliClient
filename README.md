# Simpeli REST API client (SDK)

## 1. Preface
This project is a set of tools to consume [Simpe.li](http://simpe.li/) REST API (Please check current [documentation](https://simpe.li/documentation) for the API details). 

The solution consists of 3 projects:
* SimpeliClient - the client itself. It wraps communication with the Simple.li REST API, simplifies making requests and retrieving responses. Current templates are modeled as entities.
* SimpeliWebHook - WepApi service necessary to handle the response from Simpe.li. This service is called after Simpe.li processes pdf data and generates the file.
* Tester - sample project presenting how to work with SimpeliClient.

## 2. Client usage

NOTE: To understand all parameters used in methods described below please read [Simpe.li API documentation](https://simpe.li/documentation) first. Below information are just an overview, not a technical documentation. To understand the flow of API, follow its documentation. To know all methods and types check documentation file in /docs directory.

Client initialization requires 2 parameters: 
* API_KEY - your API key (check Simpe.li settings to get/generate it)
* API_URL - the API root URL

Initialization:
```C#
SimpeliClient client = new SimpeliClient(API_KEY, API_URL);
```

To generate object with data for template:
```C#

Receipt receipt = new Receipt();
receipt.accountBilled = "1233-554-525";
receipt.amount = "120";
receipt.chargedTo = "John S.";
receipt.contact = "Johnny@pl.ok";
receipt.date = DateTime.Now.ToString();
receipt.images = new string[] { "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAAAAAA6fptVAAAACklEQVR4nGNiAAAABgADNjd8qAAAAABJRU5ErkJggg==" };
receipt.item = "Pink Bicycle";
receipt.paymentFor = "-";
receipt.transactionId = "22/56";
```

To generate a pdf you have to call SavePdf() method:
```C#
SavePdfResponse response = client.SavePdf(receipt, WEB_HOOK, "my_ref_number");
```
Where arguments are:
* template data object, 
* WebHook url that will be called by the API to send generated PDF file,
* pdf reference number

SavePdf() method requires object that implements the ITemplate interface. All current templates are defined in /Source/SimpeliClient/Templates directory. Parameters structure and naming convention strictly follow the format defined in the API documentation.

NOTE: make sure your WEB_HOOK url is correct and the service is ready to accept call from Simpe.li. You can use SimpeliWebHook project or create an account in [requestb.in](http://requestb.in/) and pass this an a WEB_HOOK.

Check credit balance:
```C#
CreditsResponse response = client.GetCredits();
Console.WriteLine("Credits: "+response.amount.ToString());
```

### Error handling
Client encapsulates all API error responses and throws as exceptions (SimpeliException class). Error details are stored in the Error property of the exception. 

Example:

```C#
try
{
    AddPaymentResponse response = null;

    response = client.AddPayment(paymentId);

    Console.WriteLine("Result of payment: " + response.message);
}
catch (SimpeliException ex)
{
    Console.WriteLine(ex.Error.StatusCode.ToString() + ":" + ex.Error.Data);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```


## 3. WebHook service installation
Publish the project in IIS. Make to give an accessible path to the directory where PDFs will be stored.

To check service is working and is visible outside you can use its ping method: http://hostwithyourwebhook.com/ping (should return string "pong").

