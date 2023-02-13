import Search from "./Search";
import Categories from "./Categories";
import Specialization from "./Specialization";
import "./Searcher.css";

function Searcher() {
	return (
		<main className="searcher">
			<Categories />
			<Search />

		</main>
	);
}

export default Searcher;
