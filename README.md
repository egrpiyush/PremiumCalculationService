# PremiumCalculationService
This service is an Azure Functions project. For abstraction within Functions and Application layer it used Command Query Repository Pattern (CQRS). The most important intention behind using CQRS here is to abstract query/command handling from invocation and to keep the function layer clean.

It uses Domain Driven Design's onion architecture (Anaemic domain).
The entities that I could identify are as follow -
  - Occupation
  - Rating and
  - OccupationRating
  
It uses IOccupationRepository, IRatingRepository and IOccupationRatingRepository for seeding data. In order to connect with database, the only change that needs to be done is in these repositories. For the purpose of this demonstration, this service uses local data (hard-coded).

Arrangements of projects is as follows -

1) Domain: the inner most layer (standalone)
1) Common: common project for AutoFac wild card implementation.
2) Application: This project comprises of the business logic ie. Queries and Commands. Its depends on Domain layer.
  - Each query in this layer has it's own model classes defined.
3) Application.Tests: From the perspective of structure, this project is a mirror of Application project. It has unit test classes for queries in the Application project.
4) Functions: this is the outmost layer and exposes the required functions.

