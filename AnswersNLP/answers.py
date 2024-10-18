import spacy
import re
from transformers import pipeline

# from sklearn.feature_extraction.#text import CountVectorizer


# Load spaCy model
nlp = spacy.load("en_core_web_sm")


with open("answers.txt", "r") as file:
    answers = file.readlines()  # fFILE

# removing punctuation first
cleaned_answers = [
    re.sub(r"[^\w\s]", "", answer.strip()) for answer in answers if answer.strip()
]

# Tokenize answers
tokenized_answers = [nlp(answer) for answer in cleaned_answers]

for i, answer in enumerate(tokenized_answers):
    print(f"Answer {i + 1}: {[token.text for token in answer]}")

# Write tokenized answers to a file
with open("tokenized_answers.txt", "w") as f:
    for answer in tokenized_answers:
        tokens = [token.text for token in answer]
        f.write(" ".join(tokens) + "\n")

print("Tokenized answers saved to tokenized_answers.txt")

# fir summaries

summarizer = pipeline(
    "summarization", model="t5-small"
)  # Load the summarization pipeline

# each answer individually and save to a file
summaries = []


for i, answer in enumerate(cleaned_answers):
    if len(answer.split()) < 2:  # Skip very short answers for functionality
        print(f"Answer {i + 1} is too short for summarization: {answer}")
        summaries.append("Too short to summarize.")
        continue

    # Summarize the answer
    summary = summarizer(answer, max_length=100, min_length=100, do_sample=False)[0][
        "summary_text"
    ]
    summaries.append(summary)

    # Print summary for debugging
    print(f"Summary for Answer {i + 1}: {summary}")

# Save all summaries to a file
with open("summarized_answers.txt", "w") as file:
    for i, summary in enumerate(summaries):
        file.write(f"Summary {i + 1}: {summary}\n")

print("Summaries saved to file summarized_answers.txt")
