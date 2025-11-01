import { useYtsMovies } from "@/context/YtsMoviesContext";
import styles from "./YtsResults.module.css";
import { useRef, useEffect } from "react";
import { BiSolidDownload } from "react-icons/bi";

interface YTSquality {
  quality: string;
  qualityType: string;
  size: string;
  magnetURL: string;
}

interface YTSmovie {
  title: string;
  imageURL: string;
  year: string;
  moviePageUrl: string;
  qualities: YTSquality[];
}

function YtsResults() {
  const { ytsMovies } = useYtsMovies();
  const scrollRef = useRef<HTMLDivElement>(null);

  useEffect(() => {
    const el = scrollRef.current;
    if (!el) return;
    const handle = (e: WheelEvent) => {
      e.preventDefault();
      el.scrollLeft += e.deltaY;
    };
    el.addEventListener("wheel", handle, { passive: false });
    return () => el.removeEventListener("wheel", handle);
  }, []);

  return (
    <div className={styles.container}>
      <h3>YTS Results</h3>

      <div className={styles.movieList} ref={scrollRef}>
        {ytsMovies && ytsMovies.length > 0 ? (
          ytsMovies.map((movie: YTSmovie, index: number) => (
            <div
              key={index}
              className={styles.movieCard}
              style={{ backgroundImage: `url(${movie.imageURL})` }}
            >
              <div className={styles.cardWrapper}>
                <BiSolidDownload className={styles.downloadIcon} />
                <div className={styles.title}>
                  {movie.title} ({movie.year})
                </div>
              </div>
            </div>
          ))
        ) : (
          <p>No results found</p>
        )}
      </div>
    </div>
  );
}

export default YtsResults;
