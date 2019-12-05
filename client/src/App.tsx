import React from "react";
import axios from "axios";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import PostList from "./components/PostList/PostList.js";
import Post from "./components/Post/Post.js";
import CreatePost from './components/Post/CreatePost';
import EditPost from './components/Post/EditPost'
import "./App.css";

class App extends React.Component {
  state = {
    posts: [],
    post: null
  };

  componentDidMount() {
    axios
      .get("http://localhost:5000/api/posts")
      .then(response => {
        this.setState({
          posts: response.data
        });
      })
      .catch(error => {
        console.error(`Error fetching data: ${error}`);
      });
  }

  viewPost = post => {
    console.log(`view ${post.title}`);
    this.setState({
      post: post
    });
  };

  deletePost = post => {
    axios
      .delete(`http://localhost:5000/api/posts/${post.id}`)
      .then(response => {
        const newPosts = this.state.posts.filter(p => p.id !== post.id);
        this.setState({
          posts: [...newPosts]
        });
      })
      .catch(error => {
        console.error(`Error deleting post: ${error}`);
      });
  };

  editPost = post => {
    this.setState({
      post: post
    });
  };

  onPostCreated = post => {
    const newPosts = [...this.state.posts, post];
    this.setState({
      posts: newPosts
    });
  };

  onPostUpdated = post => {
    console.log("updated post: ", post);
    const newPosts = [...this.state.posts];
    const index = newPosts.findIndex(p => p.id === post.id);

    newPosts[index] = post;

    this.setState({
      posts: newPosts
    });
  };

  render() {
    const { posts, post } = this.state;

    return (
      <Router>
        <div className="App">
          <header className="App-header">Famous Quotes</header>
          <nav>
            <Link to="/">Home</Link>
            <Link to="/new-post">New Post</Link>
            <a href="https://zealous-goodall-b7a30b.netlify.com/">Portfolio</a>
            <a href="https://www.linkedin.com/in/besian-kodra/">LinkedIn</a>
            <a href="https://github.com/KodraB">GitHub</a>
            <a href="https://mcaweb.matc.edu/kodrab/160/index.html">ITDEV 160</a>
            <a href="mailto:kodrab@gmatc.matc.edu">Email</a>
          </nav>
          <main className="App-content">
            <Switch>
              <Route exact path="/">
                <PostList
                  posts={posts}
                  clickPost={this.viewPost}
                  deletePost={this.deletePost}
                  editPost={this.editPost}
                />
              </Route>
              <Route path="/posts/:postId">
                <Post post={post} />
              </Route>
              <Route path="/new-post">
                <CreatePost onPostCreated={this.onPostCreated} />
              </Route>
              <Route path="/edit-post/:postId">
                <EditPost post={post} onPostUpdated={this.onPostUpdated} />
              </Route>
            </Switch>
          </main>
          <header className="App-footer">Besian Kodra | ITDEV 162 | Project 2</header>
        </div>
      </Router>
    );
  }
}

export default App;
