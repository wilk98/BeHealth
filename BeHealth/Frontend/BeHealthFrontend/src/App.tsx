import "./App.css";
import Footer from "./components/Footer/Footer";
import { Routes, Route } from "react-router-dom";
import ArangeVisit from "./components/ArangeVisit";

function App() {
	return (
		<div className="App">
			<Routes>
				<Route path="/arange-visit" element={<ArangeVisit />} />
			</Routes>
			<Footer />
		</div>
	);
}

export default App;
