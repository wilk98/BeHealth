import "./App.css";
import Footer from "./components/layout/Footer/Footer";
import { Routes, Route } from "react-router-dom";
import ArrangeVisit from "./pages/ArrangeVisit";
import { Navbar } from "./components/layout/Navbar";
import { Sidebar } from "./components/layout/Sidebar";
import CategoriesSearch from "./pages/CategoriesSearch";
import { Visits } from "./pages/doctor/Visits";
import { Calendar } from "./pages/doctor/Calendar";
import { Login } from "./pages/auth/Login";
import { Register } from "./pages/auth/register/Register";
import { BeHealthContext } from "./Context";
import { useState } from "react";
import { User } from "./utils/auth";

function App() {

	const [openSidebar, setOpenSidebar] = useState(false)
	const toggleSidebar = () => setOpenSidebar(prev => !prev);

	const [currentUser, setCurrentUser] = useState<User>()
	const [token, setToken] = useState("")

	return (
		<>
		<BeHealthContext.Provider value={{ user: currentUser, setUser: setCurrentUser, token: token, setToken: setToken }}>
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
		</BeHealthContext.Provider>
		</>
	);
}

export default App;
