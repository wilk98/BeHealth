import Search from "./Search";
import Categories from "./Categories";
import Specialization from "./Specialization";

function Searcher() {
	return (
		<main className="searcher">
			<Categories />
			<Search />
			<Specialization/>

		</main>
	);
}

export default Searcher;
