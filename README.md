# Movies scraper to be used on a NAS in Docker with VPN

C# backend and React/Ts frontend.  
Backend uses Selenium for scraping.  
dotnet watch run  
npm run dev

## Seach result testing:

Drivers opens on search. Single driver per scraper. Driver closes after scrape.  
Result time: open season: Movies: 4.565 , 6 , 4,57 , 5 , 3.9 , 4.9  
<br/>
Drivers opens on backend run. Single driver per scraper. Drivers running utill backend shut down.  
Result time: open season: Movies: 5, 3.3 , 4.4 , 5.1 , 3 , 3.5 , 5.4 , 3.5 , 3.2
