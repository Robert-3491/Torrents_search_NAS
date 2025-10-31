import { YtsMoviesProvider } from "./YtsMoviesContext";

export function AppProvider({ children }: any) {
  return <YtsMoviesProvider>{children}</YtsMoviesProvider>;
}
