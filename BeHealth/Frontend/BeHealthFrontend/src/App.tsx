import "./App.css";
import Footer from "./components/layout/Footer/Footer";
import { Routes, Route } from "react-router-dom";
import ArangeVisit from "./pages/ArangeVisit";
import { Navbar } from "./components/layout/Navbar";
import CategoriesSearch from "./pages/CategoriesSearch";

function App() {
	return (
		<div className="App">
			<Navbar />
			<Routes>
				<Route path="/arange-visit" element={<ArangeVisit />} />
				<Route path="/categories-search" element={<CategoriesSearch />} />
			</Routes>
			<Footer />
		</div>
	);
}

export default App;
