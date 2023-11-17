import { Route, Routes } from "react-router-dom";
import Home from "./pages/Home";
import SignUp from "./pages/SignUp";

function App() {
  return (
    <Routes>
      <Route index element={<Home />} />
      <Route path="/sign-up" element={<SignUp />} />
    </Routes>
  );
}

export default App;
