import { useEffect, useState } from "react";
import styles from "./BackendStatus.module.css";

export default function BackendStatus() {
  const [backendStatus, setBackendStatus] = useState<boolean>(false);

  useEffect(() => {
    fetch("http://localhost:5000/api/status")
      .then((response) => response.json())
      .then((data) => setBackendStatus(data.message));
  }, []);

  return <p id={styles.backendStatus}>{backendStatus ? "🟢" : "🔴"}</p>;
}
