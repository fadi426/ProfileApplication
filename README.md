# ProfileApplicationAPI

An API to retrieve nearby weather, news, events and movie information.
This API was mainly used for locations within The Netherlands,
although the news and events endpoint could also be used for locations outside.

# Usage

-To retrieve all the locations in the netherlands use:
  https://localhost:5001/api/profile/locations
  
-To retrieve the geological information about the given location use:
  https://localhost:5001/api/profile/locations{{location}}
  
-To retrieve the weather information use:
  https://localhost:5001/api/profile/locations/{{location}}/weather
  
-To retrieve the news information use:
https://localhost:5001/api/profile/locations/{{location}}/news

-To retrieve the events information use:
https://localhost:5001/api/profile/locations/{{location}}/events

-To retrieve the movie information use:
https://localhost:5001/api/profile/locations/{{location}}/movies
