import React from "react";
import './Card.css';

const Card = ({ name, lastName, specialization, imageUrl }) => {

    return (
        <div className="card">
            {imageUrl && <img src={imageUrl} alt={'${name} ${lastName}'} className="card-image"/>}
            <h3>{name} {lastName}</h3>
            <p>{specialization}</p>
        </div>
    );
};

export default Card;