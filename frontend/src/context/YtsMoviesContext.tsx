import { createContext, useContext, useState } from "react";

const YtsMoviesContext = createContext<any>(null);

export function YtsMoviesProvider({ children }: any) {
  const [ytsMovies, setYtsMovies] = useState([]);
  return (
    <YtsMoviesContext.Provider value={{ ytsMovies, setYtsMovies }}>
      {children}
    </YtsMoviesContext.Provider>
  );
}

export const useYtsMovies = () => useContext(YtsMoviesContext);
