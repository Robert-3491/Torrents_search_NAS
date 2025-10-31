import styles from "./SearchMode.module.css";

interface Props {
  isMovieSearch: boolean;
  setIsMovieSearch: (val: boolean) => void;
}

function SearchMode({ isMovieSearch, setIsMovieSearch }: Props) {
  //const [isMovieSearch, setIsMovieSearch] = useState(true);

  return (
    <div className={styles.container}>
      <div
        className={[
          styles.button,
          styles.left,
          isMovieSearch && styles.active,
        ].join(" ")}
        onClick={() => setIsMovieSearch(true)}
      >
        Movie
      </div>
      <div
        className={[
          styles.button,
          styles.right,
          !isMovieSearch && styles.active,
        ].join(" ")}
        onClick={() => setIsMovieSearch(false)}
      >
        Series
      </div>
    </div>
  );
}

export default SearchMode;
