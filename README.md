# Common Services

A collection of sample libraries which demonstrate common backend web patterns in .NET

### Web Access Service
A demo library that consumes the EVE Online XML API to demonstrate how to use the System.NET.Http infrastructure.
* Implement throttling using httpClient message handlers to respect the rate limit of web services 
* Implement diagnostics and logging in NLog in the message handling pipeline
* Use autofac as an IoC container for dependency injection and lifetime management 
* Expose data as a repository from web services. This allows integration/unit tests to stub out responses from a web service 
* Register one httpclient per web service to improve performance by pooling sockets 