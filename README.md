# EEPA

Extensible Enterprise Plugin Architecture


![](https://rawgithub.com/divanvisagie/EEPA/master/Diagram/EEPA.svg)



#### Using EEPA.Library

Client: 
```cs
new Client().Call<IDomainMessage, IDomainMessage>(fibonacci);
```


Consumer:
```cs
new Listener().Listen<Fibonacci>("queuename", inMessage => new AnswerMessage());
```