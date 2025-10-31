# Movies scraper to be used on a NAS in Docker with VPN

Removes 480&720p reuslts. Makes sure the search query in present in the results.  
<br/>
C# backend and React/Ts frontend.  
Backend uses Selenium for scraping.  
dotnet watch run  
npm run dev

## Seach result testing:

Drivers open on search. Single driver per scraper. Driver closes after scrape.  
Result time: open season: Movies: 4.565 , 6 , 4,57 , 5 , 3.9 , 4.9  
<br/>
Drivers open on backend run. Single driver per scraper. Drivers running utill backend shut down.  
Result time: open season: Movies: 5, 3.3 , 4.4 , 5.1 , 3 , 3.5 , 5.4 , 3.5 , 3.2
