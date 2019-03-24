# Xamarin.Forms.Calendar (*namespace will change*).

Cross Platform Calendar 

Design calendar data model, allow custom images per day, custom headers between months and raise event upon tapping on event/day, scrolling between months/year.

Calendar design needs to take Apple/Google design recommendations
  - vertical scroll on iOS.
  - horizontal on Android).
  
Calendar setup will allow
  - calendar min/max dates.
  - displaying single month/multiple months.
  - enable/disable specific days (to allow for custom holidays etc).
  - week view, displaying a single week with horizontal scrolling.

 DataSource
  - allow binding of custom data source, to display data in calendar.
    events fire as data needed to populate calendar.
 
  CalendarCells
  - each cell will be configurable
    * providing an icon for 3 states
      1. selection
      2. de-selection
      3. other
  
    * more to come.
