import { useEffect, useState } from "react";
import './DentalsTable.css';

interface Dentist {
  name: string;
  lastName: string;
}

const DentalsTable = () => {
  const [dentists, setDentists] = useState<Dentist[]>([]);
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
      <tr>
        <th>Ime</th>
        <th>Prezime</th>
      </tr>
      {dentists.map(d => (
        <tr>
          <td>{d.name}</td>
          <td>{d.lastName}</td>
        </tr>
      ))}
    </table>
  );
};

export default DentalsTable;
