import React, { useEffect, useState } from "react";
import Card from "./Card";
import Boris from "../../assets/Boris.png";
import Ljuba from "../../assets/Ljuba.png";
import Jasmina from "../../assets/Jasmina.png"; 

const dentistImages = { 
    1: Ljuba,
    2: Jasmina,
    3: Boris
};

const DentistList = () => {
    const[dentist, setDentist] = useState([]);
    const[loading, setLoading] = useState(true);
    const[error, setError] = useState(null);

    useEffect(() => {
        const fetchDentist = async () => {
            try {
                const response = await fetch('https://localhost:44389/api/Dentists');
                if(!response.ok){
                    throw new Error('Failed to fetch data');
                }
                const data = await response.json();
                setDentist(data);
            } catch (err) {
                setError(err.message);
            } finally {
                setLoading(false);
            }
        };

        fetchDentist();
    }, []);

    if(loading) return <p>Učitavanje...</p>
    if(error) return <p>Greška: {error}</p>
    
    return (

        <div className="dentist-list">
            {dentist.map((dentist) => (
                <Card
                    key = {dentist.id}
                    name = {dentist.name}
                    lastName = {dentist.lastName}
                    specialization = {dentist.specialization}
                    imageUrl = {dentistImages[dentist.id]}
                />
            )) }
        </div>
    );
};

export default DentistList;