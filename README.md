[![.NET](https://github.com/aimenux/YarpDemo/actions/workflows/ci.yml/badge.svg)](https://github.com/aimenux/YarpDemo/actions/workflows/ci.yml)

# YarpDemo
```
Playing with Yarp reverse proxy
```

> In this demo, i m using [Yarp](https://microsoft.github.io/reverse-proxy/) in order to build a lightweight app gateway intercepting requests and redirecting them to backend microservices.
>
> The solution is organized as follow :
>
> - `AppGateway` : a webapi with yarp integration and configuration
> - `CustomersMicroservice` : a dummy webapi with endpoint exposed on `https://localhost:5010/api/customers`
> - `OrdersMicroservice` : a dummy webapi with endpoint exposed on `https://localhost:5020/api/orders`
> - `ProductsMicroservice` : a dummy webapi with endpoint exposed on `https://localhost:5030/api/products`
>
> The solution is using [Tye](https://github.com/dotnet/tye) in order to configure and run microservices and app gateway.
>
> In order to run the solution : 
>
>> :one: type `Tye Run` in your favorite terminal 
>>
>> :two: browse the url `https://localhost:5000/api`
>>
>> :three: refresh the url to see Yarp in action
>
> ![TyeDashboard](Screenshots/TyeDashboard.png)
>

**`Tools`** : vs19, net core 3.1, tye, yarp