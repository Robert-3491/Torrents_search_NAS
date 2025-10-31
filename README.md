# Movies scraper to be used on a NAS in Docker with VPN

C# backend and React/Ts frontend.
<br/>
Backend uses Selenium for scraping.
<br/>
dotnet watch run
<br/>
npm run dev
<br/>

## Seach result testing:

<br/>
Drivers opens on search. Single driver per scraper. Driver closes after scrape.
Result time: open season: Movies: 4.565 , 6 , 4,57 , 5 , 3.9 , 4.9
<br/>
<br/>
Drivers opens on backend run. Single driver per scraper. Drivers running utill backend shut down.
Result time: open season: Movies: 5, 3.3 , 4.4 , 5.1 , 3 , 3.5 , 5.4 , 3.5 , 3.2
<br/>
