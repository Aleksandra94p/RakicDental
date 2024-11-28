import React from "react";
import './App.css';
import Header from "./components/Header/Header";
import DentistList from "./components/card/DentistList";

function App (){
  return(
    <div className="App">
      <Header/>
      <DentistList/>
    </div>
  );
}
export default App;