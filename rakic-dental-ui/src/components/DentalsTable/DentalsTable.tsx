import { useEffect, useState } from "react";
import Dentist from "../Dentist/Dentist";
import { useNavigate } from "react-router-dom";

import "./DentalsTable.css";

interface Dentist {
  name: string;
  lastName: string;
  id: number;
}

const DentalsTable = () => {
  const [dentists, setDentists] = useState<Dentist[]>([]);

  const navigate = useNavigate();


  useEffect(() => {
    fetch("https://localhost:44389/api/Dentists", {
      method: "GET",
    })
      .then((response) => response.json())
      .then((data) => {
        setDentists(data);
      })
      .catch((error) => console.log(error));
  }, []);

  return (
    <table>
      <thead>
        <tr>
          <th colSpan={2}>Doktori</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        {dentists.map((d) => (
          <tr key={d.id} onClick={() => navigate(`/dentist/${d.id}`)}>
            <td>{d.name}</td>
            <td>{d.lastName}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default DentalsTable;
