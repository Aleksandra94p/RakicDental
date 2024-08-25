import { useEffect, useState } from "react";

import { useParams } from "react-router-dom";
import "./Dentist.css";

interface DentistData {
  name: string;
  lastName: string;
}

const Dentist = () => {
  const [name, setName] = useState("");
  const [lastName, setLastName] = useState("");

  function setDentistData(data: DentistData) {
    setName(data.name);
    setLastName(data.lastName);
  }

  const { id } = useParams();

  useEffect(() => {
    fetch(`https://localhost:44389/api/Dentists/${id}`)
      .then((res) => res.json())
      .then((data) => {
        setDentistData(data);
      });
  }, []);

  return (
    <div className="dentist-container">
      <h3>Doktor:</h3>
      {name && <p>{name}</p>}
      {lastName && <p>{lastName}</p>}
    </div>
  );
};

export default Dentist;
