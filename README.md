# ProfileApplicationAPI

An API to retrieve nearby weather, news, events and movie information.
This API was mainly used for locations within The Netherlands,
although the news and events endpoint could also be used for locations outside.

# Usage
Root url: https://profileapplicationapi.azurewebsites.net/api/profile/

-To retrieve all the locations in the netherlands use:
  https://profileapplicationapi.azurewebsites.net/api/profile/locations
  
-To retrieve the geological information about the given location use:
  https://profileapplicationapi.azurewebsites.net/api/profile/locations/{{location}}
  
-To retrieve the weather information use:
  https://profileapplicationapi.azurewebsites.net/api/profile/locations/{{location}}/weather
  
-To retrieve the news information use:
  https://profileapplicationapi.azurewebsites.net/api/profile/locations/{{location}}/news

-To retrieve the events information use:
  https://profileapplicationapi.azurewebsites.net/api/profile/locations/{{location}}/events

-To retrieve the movie information use:
  https://profileapplicationapi.azurewebsites.net/api/profile/locations/{{location}}/movies
