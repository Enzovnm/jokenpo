import { Route, Routes } from "react-router";
import JokenpoHero from "./components/JokenpoHero/JokenpoHero";
import Navbar from "./components/Navbar/Navbar";
import { Moves } from "./components/Moves/Moves";

function App() {
  return (
    <>
      <Navbar />
      <Routes>
        <Route path="/" element={<JokenpoHero />} />
        <Route path="/moves" element={<Moves />} />
      </Routes>
    </>
  );
}

export default App;
