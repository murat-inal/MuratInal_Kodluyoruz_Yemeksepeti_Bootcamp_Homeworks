import React, { useState } from "react";

function Form({ addTodo }) {
  const [value, setValue] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    addTodo(value);
    setValue("");
  };

  return (
    <form onSubmit={handleSubmit} className="form">
      <input
        type="text"
        className="input"
        value={value}
        onChange={(e) => setValue(e.target.value)}
        placeholder="Enter Todo Here"
      />
      <input
        type="submit"
        className="add-btn"
        value="Add"
        onClick={handleSubmit}
      />
    </form>
  );
}

export default Form;
