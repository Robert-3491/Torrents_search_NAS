import BackendStatus from "./BackendStatus/BackendStatus";
import IndexSearchBar from "./IndexSearchBar/IndexSearchBar";
import styles from "./Header.module.css";
import SearchMode from "./SearchMode/SearchMode";
import { useState } from "react";

export default function Header() {
  const [isMovieSearch, setIsMovieSearch] = useState(true);

  return (
    <div>
      <div className={styles.searchBar}>
        <BackendStatus />
        <IndexSearchBar isMovieSearch={isMovieSearch} />
      </div>
      <SearchMode
        isMovieSearch={isMovieSearch}
        setIsMovieSearch={setIsMovieSearch}
      />
    </div>
  );
}
