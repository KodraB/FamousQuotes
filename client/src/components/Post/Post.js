import React from "react";
import styles from "./styles.css";

const Post = props => {
  const { post } = props;

  return (
    <div>
      <h1>{post.title}</h1>
      <p>{post.body}</p>
      <h3>{post.author}</h3>
    </div>
  );
};

export default Post;
