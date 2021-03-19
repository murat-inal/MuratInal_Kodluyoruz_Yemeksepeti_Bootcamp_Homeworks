import React from "react";

function List({ todo, index, deleteTodo }) {
  return (
  <div className="list">
    
      {todo.text}
      <button onClick={()=>deleteTodo(index)}>Delete</button>
      </div>
      );
}

export default List;
