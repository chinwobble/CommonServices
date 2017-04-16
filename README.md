# Common Services

Implementation of common backend web patterns in .NET

### Web Access Service
* Use autofac as an IoC container
* Expose data as a repository from web services as a mock
* Use autofac to allow dependency injection 
* Register one httpclient per web service to improve performance by pooling sockets 