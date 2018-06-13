# Enterprisy Functions

This is the source code I cover in my talk "Azure Functions Aren't Enterprisy, Are They?". 

In this talk, I cover a new paradigm or a new way of thinking of Azure Functions and serverless. I apply some of the best practices that we're already used to follow in the big enterprise application and we thought not to be possible with Azure Functions.

### Features implemented
* Configured dependency injection with Autofac
* Configured Mediatr
* Added Unit Tests
* Configured Security with Twitter
	* Function Authorization is set to Anonymous
	* Implementing EasyAuth

### Todo
* Get ClaimsPrincipal.Current.Claims: currently not working out of the box