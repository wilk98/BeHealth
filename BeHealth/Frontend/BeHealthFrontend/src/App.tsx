import "./App.css";
import Footer from "./components/layout/Footer/Footer";
import { Routes, Route } from "react-router-dom";
import ArangeVisit from "./pages/ArangeVisit";
import { Navbar } from "./components/layout/Navbar";
import { Sidebar } from "./components/layout/Sidebar";

function App() {
	return (
		<>
			<Navbar />
			<Sidebar />
			<Routes>
				<Route path="/arange-visit" element={<ArangeVisit />} />
			</Routes>
			<Footer />
		</>
	);
}

export default App;
