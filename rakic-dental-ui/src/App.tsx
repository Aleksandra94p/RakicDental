import { Route, Routes } from "react-router-dom";

import DentalsTable from "./components/DentalsTable/DentalsTable";
import Header from "./components/Header/Header";

import "./App.css";

function App() {
  return (
    <div className="App">
      <Header />
      
      <Routes>
        <Route path="/"  element={<DentalsTable />} />
      </Routes>
    </div>
  );
}

export default App;
