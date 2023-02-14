import "./App.css";
import Footer from "./components/layout/Footer/Footer";
import { Routes, Route } from "react-router-dom";
import ArrangeVisit from "./pages/ArrangeVisit";
import { Navbar } from "./components/layout/Navbar";
import { Sidebar } from "./components/layout/Sidebar";
import { useState } from "react";
import CategoriesSearch from "./pages/CategoriesSearch";
import { Visits } from "./pages/doctor/Visits";
import { Calendar } from "./pages/doctor/Calendar";
import { Login } from "./pages/auth/Login";
import { Register } from "./pages/auth/register/Register";

function App() {
	const [openSidebar, setOpenSidebar] = useState(true)
	const toggleSidebar = () => setOpenSidebar(prev => !prev);

	return (
		<>
			<Navbar />
			<div className="container">
				<Sidebar isOpen={openSidebar} toggle={toggleSidebar} />
				<Routes>
					<Route path="/arrange-visit" element={<ArrangeVisit />} />
					<Route path="/categories-search" element={<CategoriesSearch />} />
					<Route path="/visits" element={<Visits />} />
					<Route path="/calendar" element={<Calendar />} />
					<Route path="/login" element={<Login />} />
					<Route path="/register" element={<Register />} />
				</Routes>
			</div>
			<Footer />
		</>
	);
}

export default App;
