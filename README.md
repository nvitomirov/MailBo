# MailBo is a test application for presentation purposes. 
Idea is to use and implement some of the frameworks, technologies and methodologies in software development.

MailBoService is a WCF project thought as a provider of personalized messages. It exposes a few methods for user management and returning messages sent to the user.
MailBoService is a self hosted service that means it can be run, tested and easily used by client applications just by running the MailBoServiceSelfHost project.
MailBoService has also it's test project witch is written using NUnit framework. As the methods of the service were already implemented, test were written in the refactoring phase.
All other parts of the project and solution will be developed using test driven development methodology.

MailBoConsumerApi project is intended as a logic for the client application for showing end users their messages in real time.
In this case MailBoConsumerApi communicates with MailBoService, but as the logic is not yet clear, its implementation will be loosley coupled (using IOC) which will give us a little more comfort on building client application.

MailBoClient is a portable class library that will use our MailBoConsumerApi logic and later on will be developed for different kind of end user devices.
